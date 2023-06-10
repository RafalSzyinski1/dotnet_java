import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.util.ArrayList;
import java.util.Random;
import java.util.concurrent.locks.ReentrantLock;

public class World extends JPanel {
    private static final int UPDATE_RATE = 200;
    protected ReentrantLock lock = new ReentrantLock();
    private Box box;
    private ArrayList<BouncingBall> balls;

    private DrawCanvas canvas;

    public World(int width, int height) {
        balls = new ArrayList<BouncingBall>();

        Random rand = new Random();

        box = new Box(0, 0, width, height);

        for (int i = 0; i < 30; ++i) {
            BouncingBall ball = new BouncingBall(box);

            ball.setPosition(rand.nextInt(width - 60) + 30, rand.nextInt(height - 60) + 30);
            balls.add(ball);

        }

        canvas = new DrawCanvas();
        this.setLayout(new BorderLayout());
        this.add(canvas, BorderLayout.CENTER);

        this.addComponentListener(new ComponentAdapter() {
            @Override
            public void componentResized(ComponentEvent e) {
                Component c = (Component) e.getSource();
                Dimension dim = c.getSize();
                box.set(0, 0, dim.width, dim.height);
            }
        });

        gameRun();
    }

    public void gameRun() {

        Thread gameThread = new Thread() {
            public void run() {
                double dt = 1.0/UPDATE_RATE;
                Thread[] Ball_life = new Thread[balls.size()];
                int index = 0;
                for(BouncingBall ball: balls){
                    Ball_life[index] = new Thread(()->update(ball,dt));
                    Ball_life[index].start();
                    index++;
                }
                while (true) {
                    long beginTimeMillis, timeTakenMillis, timeLeftMillis;
                    beginTimeMillis = System.currentTimeMillis();

                    //gameUpdate(1.0 / UPDATE_RATE);
                    repaint();

                    timeTakenMillis = System.currentTimeMillis() - beginTimeMillis;
                    timeLeftMillis = 1000L / UPDATE_RATE - timeTakenMillis;
                    if (timeLeftMillis < 5)
                        timeLeftMillis = 5;
                    try {
                        Thread.sleep(timeLeftMillis);
                    } catch (InterruptedException ex) {
                    }
                }
            }
        };
        gameThread.start();
    }

    public void update(BouncingBall ball, double dt){
        while(true){
            long beginTimeMillis, timeTakenMillis, timeLeftMillis;
                    beginTimeMillis = System.currentTimeMillis();

                    //lock.lock();
                    checkOthers(ball,balls,dt);
                    //lock.unlock();
                    //lock.lock();
                    checkWall(ball,box);
                    //lock.unlock();
                    lock.lock();
                    ball.update(dt);
                    lock.unlock();

                    timeTakenMillis = System.currentTimeMillis() - beginTimeMillis;
                    timeLeftMillis = 1000L / UPDATE_RATE - timeTakenMillis;
                    if (timeLeftMillis < 5)
                        timeLeftMillis = 5;
                    try {
                        Thread.sleep(timeLeftMillis);
                    } catch (InterruptedException ex) {
                    }
        }
    }

    class DrawCanvas extends JPanel {
        @Override
        public void paintComponent(Graphics g) {
            super.paintComponent(g);
            box.draw(g);
            for (Ball ball : balls)
                ball.draw(g);
        }

        @Override
        public Dimension getPreferredSize() {
            return (new Dimension(box.maxX - box.minX - 1, box.maxY - box.minY - 1));
        }
    }

    public void checkOthers(BouncingBall main_ball, ArrayList<BouncingBall> balls,double dt) {
        lock.lock();
        double my_pos[] = main_ball.getPosition();
        double my_speed[] = main_ball.getSpeed();
        double my_radius = main_ball.radius;
        lock.unlock();

        for (Ball ball : balls) {
            lock.lock();
            double his_pos[] = ball.getPosition();
            double his_speed[] = ball.getSpeed();
            double his_radius = ball.radius;
            lock.unlock();

            if (my_pos == his_pos) {
                continue;
            }

            double distance = Math.sqrt(Math.pow(my_pos[0] - his_pos[0], 2) + Math.pow(my_pos[1] - his_pos[1], 2));
            if(distance < (my_radius + his_radius)*0.9){
                lock.lock();
                ball.setPosition(his_pos[0]+his_speed[0]*10*dt, his_pos[1]+his_speed[1]*10*dt);
                lock.unlock();
            }
            else if (distance <= my_radius + his_radius) {
                lock.lock();
                ball.setSpeed(-his_speed[0], -his_speed[1]);
                //ball.update(my_radius/60.0);
                lock.unlock();
                
            }
        }
    }

    public void checkWall(BouncingBall ball, Box box) {
        lock.lock();
        double act_pos[] = ball.getPosition();
        double act_speed[] = ball.getSpeed();
        lock.unlock();
        double ballMinX = box.minX + ball.radius;
        double ballMinY = box.minY + ball.radius;
        double ballMaxX = box.maxX - ball.radius;
        double ballMaxY = box.maxY - ball.radius;

        if (act_pos[0] < ballMinX) {
            lock.lock();
            ball.setSpeed(-act_speed[0], act_speed[1]);
            ball.setPosition(ballMinX, act_pos[1]);
            lock.unlock();
        } else if (act_pos[0] > ballMaxX) {
            lock.lock();
            ball.setSpeed(-act_speed[0], act_speed[1]);
            ball.setPosition(ballMaxX, act_pos[1]);
            lock.unlock();
        }

        if (act_pos[1] < ballMinY) {
            lock.lock();
            ball.setSpeed(act_speed[0], -act_speed[1]);
            ball.setPosition(act_pos[0], act_pos[1]);
            lock.unlock();
        } else if (act_pos[1] > ballMaxY) {
            lock.lock();
            ball.setSpeed(act_speed[0], -act_speed[1]);
            ball.setPosition(act_pos[0], act_pos[1]);
            lock.unlock();
        }
/*
        lock.lock();
        act_pos[0] += act_speed[0];
        act_pos[1] += act_speed[1];
        lock.unlock();
    */  }


}
