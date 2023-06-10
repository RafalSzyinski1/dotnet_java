abstract class Position {
    private double pos[];

    public Position() {
        pos = new double[2];
        pos[0] = 0;
        pos[1] = 0;
    }

    public double[] getPosition() {
        return pos;
    }

    public void setPosition(double x, double y) {
        pos[0] = x;
        pos[1] = y;
    }
}
