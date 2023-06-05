import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class World extends JPanel {
    private static final int UPDATE_RATE = 60;

    private Box box;
    private Ball ball;

    private DrawCanvas canvas;

    public World(int width, int height) {
        ball = new Ball(20, Color.RED);
        ball.setPosition(width / 2, height / 2);
        ball.setSpeed(150, 150);
        box = new Box(0, 0, width, height);

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
                double TimePerFrame = 1000.0 / UPDATE_RATE;
                double timeSinceLastUpdate = 0.0;
                double lastTimeStamp = System.currentTimeMillis();
                while (true) {
                    double dt = System.currentTimeMillis() - lastTimeStamp;
                    lastTimeStamp = System.currentTimeMillis();
                    timeSinceLastUpdate += dt;
                    while (timeSinceLastUpdate > TimePerFrame) {
                        timeSinceLastUpdate -= TimePerFrame;
                        gameUpdate(TimePerFrame / 1000);
                    }
                    repaint();
                }
            }
        };
        gameThread.start();
    }

    public void gameUpdate(double dt) {
        ball.update(dt);
    }

    class DrawCanvas extends JPanel {
        @Override
        public void paintComponent(Graphics g) {
            super.paintComponent(g);
            box.draw(g);
            ball.draw(g);
        }

        @Override
        public Dimension getPreferredSize() {
            return (new Dimension(box.maxX - box.minX - 1, box.maxY - box.minY - 1));
        }
    }
}
