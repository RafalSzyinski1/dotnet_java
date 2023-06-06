# Bouncing Balls

https://www3.ntu.edu.sg/home/ehchua/programming/java/J8a_GameIntro-BouncingBalls.html

## Zadania

1. Zabezpieczyć getPosition() setPosition() mutexem

2. Zabezpieczyć getSpeed() setSpeed() mutexem

3. Napisać metode BouncingBall::bounce(BouncingBall other), która sprawdza czy ta kula styka się z inną kulą jeśli tak to odbić tą kule (nie inną) [zabezpieczyć przed sprawdzeniem samej siebie this != other]

JEST 4. Napisać metode BouncingBall::bounce(Box window), która sprawdza czy kula styka się z oknem jeśli tak odbić tą kule

5. w metodzie World::updateGame() odpalić wątki dla każdej kuli który w pętli wywołuje bounce(BouncingBall) i na końcu bounce(window)

6. Join'ować wszystkie wątki