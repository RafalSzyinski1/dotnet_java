import java.awt.Color;
import java.util.ArrayList;
import java.util.Random;

public class BouncingBall extends Ball {

    public BouncingBall(Box box) {
        Random rand = new Random();

        // Testing values
        setRadius(rand.nextInt(30));
        setSpeed(rand.nextInt(10), rand.nextInt(10));
        setColor(new Color(rand.nextInt(255), rand.nextInt(255), rand.nextInt(255)));
    }

    public void checkWall(Box box) {
        double act_pos[] = getPosition();
        double act_speed[] = getSpeed();
        double ballMinX = box.minX + radius;
        double ballMinY = box.minY + radius;
        double ballMaxX = box.maxX - radius;
        double ballMaxY = box.maxY - radius;
        act_pos[0] += act_speed[0];

        if (act_pos[0] < ballMinX) {
            lock.lock();
            setSpeed(-act_speed[0], act_speed[1]);
            setPosition(ballMinX, act_pos[1]);
            lock.unlock();
        } else if (act_pos[0] > ballMaxX) {
            lock.lock();
            setSpeed(-act_speed[0], act_speed[1]);
            setPosition(ballMaxX, act_pos[1]);
            lock.unlock();
        }

        if (act_pos[1] < ballMinY) {
            lock.lock();
            setSpeed(act_speed[0], -act_speed[1]);
            setPosition(act_pos[0], act_pos[1]);
            lock.unlock();
        } else if (act_pos[1] > ballMaxY) {
            lock.lock();
            setSpeed(act_speed[0], -act_speed[1]);
            setPosition(act_pos[0], act_pos[1]);
            lock.unlock();
        }
    }

    public void checkOthers(ArrayList<BouncingBall> balls) {
        double my_pos[] = getPosition();
        double my_radius = radius;

        for (Ball ball : balls) {
            double his_pos[] = ball.getPosition();
            double his_speed[] = ball.getSpeed();
            double his_radius = ball.radius;

            if (my_pos == his_pos) {
                continue;
            }

            double distance = Math.sqrt(Math.pow(my_pos[0] - his_pos[0], 2) + Math.pow(my_pos[1] - his_pos[1], 2));

            if (distance < my_radius + his_radius) {
                lock.lock();
                ball.setSpeed(-his_speed[0], -his_speed[1]);
                lock.unlock();
            }
        }

    }

}
