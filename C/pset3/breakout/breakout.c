//
// breakout.c
//
// Computer Science 50
// Problem Set 3
//

// standard libraries
#define _XOPEN_SOURCE
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

// Stanford Portable Library
#include <spl/gevents.h>
#include <spl/gobjects.h>
#include <spl/gwindow.h>

// height and width of game's window in pixels
#define HEIGHT 600
#define WIDTH 400

// number of rows of bricks
#define ROWS 5

// number of columns of bricks
#define COLS 10

// lives
#define LIVES 3

// bricks
#define BRICKMARGIN 4
#define BRICKHEIGHT 10
#define BRICKLENGTH ((WIDTH / COLS) - BRICKMARGIN)

// paddle
#define PADDLE_Y HEIGHT - (BRICKHEIGHT * 2)
#define PADDLE_X WIDTH / 2 - BRICKLENGTH

// ball
#define RADIUS 20
#define BALL_Y HEIGHT - (BRICKHEIGHT * 2 + RADIUS)
#define BALL_X (WIDTH / 2) - (RADIUS / 2)

// prototypes
void initBricks(GWindow window);
GOval initBall(GWindow window);
GRect initPaddle(GWindow window);
GLabel initScoreboard(GWindow window);
void updateScoreboard(GWindow window, GLabel label, int points, int lives);
GObject detectCollision(GWindow window, GOval ball);

int main(void)
{
    // seed pseudorandom number generator
    srand48(time(NULL));

    // instantiate window
    GWindow window = newGWindow(WIDTH, HEIGHT);

    // instantiate bricks
    initBricks(window);

    // instantiate ball, centered in middle of window
    GOval ball = initBall(window);

    // instantiate paddle, centered at bottom of window
    GRect paddle = initPaddle(window);

    // instantiate scoreboard, centered in middle of window, just above ball
    GLabel label = initScoreboard(window);

    // number of bricks initially
    int bricks = COLS * ROWS;

    // number of lives initially
    int lives = LIVES;

    // number of points initially
    int points = 0;
    
    // speed of ball
    double velocityX = drand48() + 1;
    double velocityY = -3.0;

    // keep playing until game over
    while (lives > 0 && bricks > 0)
    {
        updateScoreboard(window, label, points, lives);

        // listen for mouse event
        GEvent event = getNextEvent(MOUSE_EVENT);
        // if we heard any event
        if (event != NULL)
        {
            // if the event was movement
            if (getEventType(event) == MOUSE_MOVED)
            {
                // ensure paddle follows the cursor along the x-axis
                double x = getX(event) - getWidth(paddle) / 2;
                setLocation(paddle, x, PADDLE_Y);
            }
        }
        
        // move ball
        move(ball, velocityX, velocityY);

        // bounce off right edge of window
        if (getX(ball) + RADIUS >= WIDTH)
        {
            velocityX = -velocityX;
        }
        // bounce off left edge of window
        else if (getX(ball) <= 0)
        {
            velocityX = -velocityX;
        }     
        // bounce off the top
        if (getY(ball) <= 0)
        {
            velocityY = -velocityY;
        }
        // if the paddle misses the ball, remove a life and reset
        if (getY(ball) >= PADDLE_Y)
        {
            lives--;            
            updateScoreboard(window, label, points, lives);
            setLocation(paddle, PADDLE_X, PADDLE_Y);
            setLocation(ball, BALL_X, BALL_Y);
            if (lives > 0 && bricks > 0)
                waitForClick();
        }
        pause(10);
        // detect collision
        GObject object = detectCollision(window, ball);
        
        if (object != NULL)
        {
            if (object == paddle)
            {
                velocityY = -velocityY - .1;
                velocityX = velocityX - .5;
            }
            else if (strcmp(getType(object), "GRect") == 0)
            {
                removeGWindow(window, object);
                velocityY = -velocityY;
                points++;
                bricks--;
                updateScoreboard(window, label, points, lives);
            }
        }
        if (bricks > 0 && lives == 0)
        {
            char s[9];
            sprintf(s, "You lose!");
            setLabel(label, s);
            setLocation(label, (WIDTH - getWidth(label)) / 2, (HEIGHT - getHeight(label)) / 2);
        }
        else if (bricks <= 0 && lives > 0)
        {
            char s[8];
            sprintf(s, "You win!");
            setLabel(label, s);
            setLocation(label, (WIDTH - getWidth(label)) / 2, (HEIGHT - getHeight(label)) / 2);
        }
        
        
    }

    // wait for click before exiting
    waitForClick();

    // game over
    closeGWindow(window);
    return 0;
}

/**
 * Initializes window with a grid of bricks.
 */
void initBricks(GWindow window)
{
    int brickY = BRICKLENGTH + BRICKMARGIN;

    for (int i = 0; i < ROWS; i++)
    {
        int brickX = BRICKMARGIN - (BRICKMARGIN / 2);
        for (int j = 0; j < COLS; j++)
        {
            GRect brick = newGRect(brickX, brickY, BRICKLENGTH, BRICKHEIGHT);
            
            if (i == 0)
                setColor(brick, "ffff9d");
            
            if (i == 1)
                setColor(brick, "beeb9f");
            
            if (i == 2)
                setColor(brick, "79bd8f");
            
            if (i == 3)
                setColor(brick, "00a388");
            
            if (i == 4)
                setColor(brick, "ff6138");

            setFilled(brick, true);
            add(window, brick);
            brickX+=(BRICKLENGTH + BRICKMARGIN);
        }
        brickY+=(BRICKHEIGHT + BRICKMARGIN);
    }
}

/**
 * Instantiates ball in center of window.  Returns ball.
 */
GOval initBall(GWindow window)
{
    GOval ball = newGOval(BALL_X, BALL_Y, RADIUS, RADIUS);
    setColor(ball, "83d1e8");
    setFilled(ball, true);
    add(window, ball);
    return ball;
}

/**
 * Instantiates paddle in bottom-middle of window.
 */
GRect initPaddle(GWindow window)
{
    GRect paddle = newGRect(PADDLE_X, PADDLE_Y, BRICKLENGTH * 2, BRICKHEIGHT);
    setColor(paddle, "646464");
    setFilled(paddle, true);
    add(window, paddle);
    return paddle;
}

/**
 * Instantiates, configures, and returns label for scoreboard.
 */
GLabel initScoreboard(GWindow window)
{
    GLabel label = newGLabel("Start");
    setFont(label, "SansSerif-28");
    setColor(label, "83d1e8");
    add(window, label);
    return label;
}

/**
 * Updates scoreboard's label, keeping it centered in window.
 */
void updateScoreboard(GWindow window, GLabel label, int points, int lives)
{
    // update label
    char s[28];
    sprintf(s, "Points: %i, Lives: %i", points, lives);
    setLabel(label, s);

    // center label in window
    setLocation(label, (WIDTH - getWidth(label)) / 2, (HEIGHT - getHeight(label)) / 2);
}

/**
 * Detects whether ball has collided with some object in window
 * by checking the four corners of its bounding box (which are
 * outside the ball's GOval, and so the ball can't collide with
 * itself).  Returns object if so, else NULL.
 */
GObject detectCollision(GWindow window, GOval ball)
{
    // ball's location
    double x = getX(ball);
    double y = getY(ball);

    // for checking for collisions
    GObject object;

    // check for collision at ball's top-left corner
    object = getGObjectAt(window, x, y);
    if (object != NULL)
    {
        return object;
    }

    // check for collision at ball's top-right corner
    object = getGObjectAt(window, x + RADIUS, y);
    if (object != NULL)
    {
        return object;
    }

    // check for collision at ball's bottom-left corner
    object = getGObjectAt(window, x, y + RADIUS);
    if (object != NULL)
    {
        return object;
    }

    // check for collision at ball's bottom-right corner
    object = getGObjectAt(window, x + RADIUS, y + RADIUS);
    if (object != NULL)
    {
        return object;
    }

    // no collision
    return NULL;
}
