import java.awt.Color;
import java.awt.Graphics;
import java.util.concurrent.locks.ReentrantLock;

public class Ball extends Entity implements Drawable {
    protected double radius;
    private Color color;
    protected ReentrantLock lock = new ReentrantLock();

    public Ball() {
        this.radius = 0;
        this.color = Color.WHITE;
    }

    public void setRadius(double radius) {
        if(radius<10)
        {
            this.radius=10;
        }
        else
        {
            this.radius = radius;
        }
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
