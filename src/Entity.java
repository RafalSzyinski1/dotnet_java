abstract class Entity extends Position {
    private double speed[];

    public Entity() {
        speed = new double[2];
        speed[0] = 0;
        speed[1] = 0;
    }

    public double[] getSpeed() {
        return speed;
    }

    public void setSpeed(double vx, double vy) {
        speed[0] = vx;
        speed[1] = vy;
    }

    public void update(double dt) {
        double pos[] = getPosition();
        double new_pos_x = pos[0] + speed[0] * dt;
        double new_pos_y = pos[1] + speed[1] * dt;
        setPosition(new_pos_x, new_pos_y);
    }

    public double getMoveAngle() {
      return (double)Math.toDegrees(Math.atan2(-speed[1], speed[0]));
   }
}
