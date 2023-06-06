import java.awt.Color;
import java.awt.Graphics;

public class Ball extends Entity implements Drawable {
    protected double radius;
    private Color color;

    public Ball() {
        this.radius = 0;
        this.color = Color.WHITE;
    }

    public void setRadius(double radius) {
        this.radius = radius;
    }

    public void setColor(Color color) {
        this.color = color;
    }

    @Override
    public void draw(Graphics g) {
        double pos[] = getPosition();
        g.setColor(color);
        g.fillOval((int) (pos[0] - radius), (int) (pos[1] - radius), (int) (2 * radius), (int) (2 * radius));
    }
}
