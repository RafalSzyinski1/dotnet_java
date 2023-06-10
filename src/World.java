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

        for (int i = 0; i < 50; ++i) {
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

                    lock.lock();
                    ball.checkOthers(balls,dt);
                    lock.unlock();
                    lock.lock();
                    ball.checkWall(box);
                    lock.unlock();
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
}
