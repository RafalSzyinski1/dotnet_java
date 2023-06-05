import java.awt.BorderLayout;
import javax.swing.JFrame;

public class Interface extends JFrame {

	
	public Interface() { // Constructor.

		setSize(840, 500); // Setting window size.
		setLocationRelativeTo(null); // Centering the window.
		setDefaultCloseOperation(EXIT_ON_CLOSE); // Shut down the program.
		setLayout(new BorderLayout()); // Setting the border layout.
		setTitle("Bouncing Ball Animation"); // Setting the program title.

		// image (only if this JAR
		// build).
		add(new Core()); // Adding a class to JFrame (the class must be of type Component ("extends
							// JPanel, JComponent, etc.).
		setVisible(true); // Setting visibility of the program.
	}

	public static void main(String[] args) {
		new Interface(); // Run the program
	}
}