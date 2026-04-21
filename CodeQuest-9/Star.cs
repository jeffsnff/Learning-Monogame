using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CodeQuest_9;

public class Star
{
    //attributes to make the stars work properly
    private Texture2D _starTexture;
    private float _starX;
    private float _starY;
    private float _starRotation, _starRotationChange;
    private bool _rotateClockwise;
    private Random _rng;

    //attributes to make the stars look nice
    private float _starScale, _starTransparency, _starSpeed;
    private Color _starColor;
    private Vector2 _starOrigin;

    public Star(float xCoord, float yCoord, Texture2D sprite)
    {
        _starX = xCoord;
        _starY = yCoord;
        _starTexture = sprite;

        _rng = new Random();
        _starSpeed = _rng.Next(150, 501)/100f;
        
        //will this start rotate clockwise (true), or counter clockwise (false)?
        if (_rng.Next(1, 100) < 50)
        {
            _rotateClockwise = true;
        }
        else
        {
            _rotateClockwise = false;
        }

        //all stars start at an angle of 0
        _starRotation = 0;

        //how much rotation will each star have? between 0.05 and 0.1 (see Update)
        _starRotationChange = _rng.Next(5, 10) / 100f;


        //make the stars look nice.
        //set the scale between 0.25 and 1
        _starScale = _rng.Next(25, 100) / 100f;

        //set the color to something random - not too dark though (don't go below 128 per color channel)
        _starColor = new Color(_rng.Next(128, 256), _rng.Next(128, 256), _rng.Next(128, 256));

        //set the transparency between .3 (mostly transparent) and 1.0 (not transparent at all
        _starTransparency = _rng.Next(30, 100) / 100f;

        //set our origin to the center of the star sprite so that the rotation looks good!
        _starOrigin = new Vector2((_starTexture.Width / 2f), (_starTexture.Height / 2f));
    }

    public float XCoord => _starX;
    public float YCoord => _starY;

    public void Update()
    {
        if (_rotateClockwise)
        {
            _starRotation += _starRotationChange;
        }
        else
        {
            _starRotation -= _starRotationChange;
        }

        _starY += _starSpeed;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(
            _starTexture, new Vector2(_starX, _starY), null, _starColor * _starTransparency, 
            _starRotation, _starOrigin, _starScale, SpriteEffects.None, 0);
        spriteBatch.End();
    }
}