import java.awt.Color;
import java.util.Random;

public class BouncingBall extends Ball {

    public BouncingBall(Box box) {
        Random rand = new Random();

        // Testing values
        setRadius(rand.nextInt(30));
        setSpeed(rand.nextInt(70), rand.nextInt(70));
        setColor(new Color(rand.nextInt(255), rand.nextInt(255), rand.nextInt(255)));
    }

    public void checkWall(Box box){
        double act_pos[] = getPosition();
        double act_speed[] = getSpeed();
        double ballMinX = box.minX + radius;
        double ballMinY = box.minY + radius;
        double ballMaxX = box.maxX - radius;
        double ballMaxY = box.maxY - radius;
        act_pos[0] += act_speed[0];

        if (act_pos[0]< ballMinX){
            setSpeed(-act_speed[0], act_speed[1]);
            setPosition(ballMinX, act_pos[1]);
        }
        else if (act_pos[0] > ballMaxX){
            setSpeed(-act_speed[0], act_speed[1]);
            setPosition(ballMaxX, act_pos[1]);
        }

        if (act_pos[1] < ballMinY){
            setSpeed(act_speed[0], -act_speed[1]);
            setPosition(act_pos[0], act_pos[1]);
        }
        else if (act_pos[1] > ballMaxY){
            setSpeed(act_speed[0], -act_speed[1]);
            setPosition(act_pos[0], act_pos[1]);
        }
    }
}
