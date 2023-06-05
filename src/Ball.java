import java.awt.Color;
import java.awt.Graphics;

public class Ball extends Entity implements Drawable {
    private double radius;
    private Color color;

    public Ball(double radius, Color color) {
        this.radius = radius;
        this.color = color;
    }

    @Override
    public void draw(Graphics g) {
        double pos[] = getPosition();
        g.setColor(color);
        g.fillOval((int) (pos[0] - radius), (int) (pos[1] - radius), (int) (2 * radius), (int) (2 * radius));
    }
}
