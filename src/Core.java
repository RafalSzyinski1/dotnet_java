import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.RenderingHints;
import java.awt.Toolkit;

import javax.swing.JComponent;

public class Core extends JComponent {

	private static final long serialVersionUID = 1L;
	// Global variables.
	int x, y, bounds = 80;
	boolean move_up, move_left;
	private BouncingBall ball;

	public Core() {
		this.ball = new BouncingBall();
		this.ball.setPosition(300, 300);
		this.ball.setSpeed(1, 1);
	}

	public void paintComponent(Graphics g) { // This method is called using EDT, it does not need to be called.
		Graphics2D g2d = (Graphics2D) g; // Conversion from Graphics to Graphics2D.
		super.paintComponent(g2d); // I don't know what that.
		g2d.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON); // Better resolution
																									// of the shapes.
		ball.draw(g2d);
		g2d.dispose(); // Memory optimization. Helps a lot if method has create new shape objects.
		Toolkit.getDefaultToolkit().sync(); // Rendering are OS dependent. This line makes animation smoother on Linux.
	}

}