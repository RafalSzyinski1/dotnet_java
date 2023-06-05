import java.awt.Color;
import java.util.Random;

public class BouncingBall extends Ball {

    public BouncingBall() {
        Random rand = new Random();

        // Testing values
        setRadius(rand.nextInt(30));
        setSpeed(rand.nextInt(200), rand.nextInt(200));
        setColor(new Color(rand.nextInt(255), rand.nextInt(255), rand.nextInt(255)));
    }
}
