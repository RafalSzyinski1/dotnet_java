import java.awt.Color;
import java.util.ArrayList;
import java.util.Random;

public class BouncingBall extends Ball {

    public BouncingBall(Box box) {
        Random rand = new Random();

        // Testing values
        setRadius(rand.nextInt(30));
        setSpeed(rand.nextInt(300), rand.nextInt(300));
        setColor(new Color(rand.nextInt(255), rand.nextInt(255), rand.nextInt(255)));
    }

    public void checkWall(Box box) {
        //lock.lock();
        double act_pos[] = getPosition();
        double act_speed[] = getSpeed();
        //lock.unlock();
        double ballMinX = box.minX + radius;
        double ballMinY = box.minY + radius;
        double ballMaxX = box.maxX - radius;
        double ballMaxY = box.maxY - radius;

        if (act_pos[0] < ballMinX) {
            //lock.lock();
            setSpeed(-act_speed[0], act_speed[1]);
            setPosition(ballMinX, act_pos[1]);
            //lock.unlock();
        } else if (act_pos[0] > ballMaxX) {
            //lock.lock();
            setSpeed(-act_speed[0], act_speed[1]);
            setPosition(ballMaxX, act_pos[1]);
            //lock.unlock();
        }

        if (act_pos[1] < ballMinY) {
            //lock.lock();
            setSpeed(act_speed[0], -act_speed[1]);
            setPosition(act_pos[0], act_pos[1]);
            //lock.unlock();
        } else if (act_pos[1] > ballMaxY) {
            //lock.lock();
            setSpeed(act_speed[0], -act_speed[1]);
            setPosition(act_pos[0], act_pos[1]);
            //lock.unlock();
        }
/*
        lock.lock();
        act_pos[0] += act_speed[0];
        act_pos[1] += act_speed[1];
        lock.unlock();
    */  }

    public void checkOthers(ArrayList<BouncingBall> balls,double dt) {
        //lock.lock();
        double my_pos[] = getPosition();
        double my_speed[] = getSpeed();
        double my_radius = radius;
        //lock.unlock();

        for (Ball ball : balls) {
            //lock.lock();
            double his_pos[] = ball.getPosition();
            double his_speed[] = ball.getSpeed();
            double his_radius = ball.radius;
            //lock.unlock();

            if (my_pos == his_pos) {
                continue;
            }

            double distance = Math.sqrt(Math.pow(my_pos[0] - his_pos[0], 2) + Math.pow(my_pos[1] - his_pos[1], 2));
            if(distance < (my_radius + his_radius)*0.9){
                ball.setPosition(his_pos[0]+his_speed[0]*dt, his_pos[1]+his_speed[1]*dt);
            }
            else if (distance <= my_radius + his_radius) {
                //lock.lock();
                ball.setSpeed(-his_speed[0], -his_speed[1]);
                //ball.update(my_radius/60.0);
                //lock.unlock();
                
            }
        }
    }

}
