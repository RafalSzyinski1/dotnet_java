
import java.awt.Color;
import java.awt.Graphics;

public class Box implements Drawable {
    public int minX, maxX, minY, maxY;

    public Box(int x, int y, int width, int height) {
        set(x, y, width, height);
    }

    public void set(int x, int y, int width, int height) {
        minX = x;
        minY = y;
        maxX = x + width - 1;
        maxY = y + height - 1;
    }

    @Override
    public void draw(Graphics g) {
        g.setColor(Color.BLACK);
        g.fillRect(minX, minY, maxX - minX - 1, maxY - minY - 1);
        g.setColor(Color.WHITE);
        g.drawRect(minX, minY, maxX - minX - 1, maxY - minY - 1);
    }
}
