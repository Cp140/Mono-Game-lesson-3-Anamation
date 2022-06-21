using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Mono_Game_lesson_3__Anamation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Tribble Brown
        Texture2D tribbleBrownTexture;
        Rectangle tribbleBrownRect;
        Vector2 tribbleBrownSpeed;

        //Tribble Cream
        Texture2D tribbleCreamTexture;
        Rectangle tribbleCreamRect;
        Vector2 tribbleCreamSpeed;
        //Tribble Grey
        Texture2D tribbleGreyTexture;
        Rectangle tribbleGreyRect;
        Vector2 tribbleGreySpeed;

        //Tribble Orange
        Texture2D tribbleOrangeTexture;
        Rectangle tribbleOrangeRect;
        Vector2 tribbleOrangeSpeed;

        //Background
        Texture2D backGroundTexture;
        Rectangle backGroundRect;
        Vector2 backGroundSpeed;

        SpriteFont titleFont;

        Texture2D IntroBackgroundTexture;

        Screen currentScreen;

        MouseState mouseState;

        enum Screen
        {
            Intro, 
            TribbleYard,
            Outtro
        }

        Random rnd = new Random();
        List<Color> tribbleColourList = new List<Color>() { Color.BurlyWood, Color.Transparent, Color.Yellow, Color.Red, Color.Green, Color.Blue, Color.Black};
        int rndColor;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            currentScreen = Screen.Intro;


            //Tribble Brown
            tribbleBrownSpeed = new Vector2(-10, 1);

            //tribble Cream
            tribbleCreamSpeed = new Vector2(0, -2);

            //Tribble Grey
            tribbleGreySpeed = new Vector2(2, 0);

            //Tribble Orange
            tribbleOrangeSpeed = new Vector2(-2, -2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Tribble Brown
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleBrownRect = new Rectangle (10, 10, 100, 100);

            //Tribble Cream
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleCreamRect = new Rectangle(200, 10, 100, 100);

            //Tribble Grey
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleGreyRect = new Rectangle(300, 200, 100, 100);

            //Tribble Orange
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleOrangeRect = new Rectangle(300, 100, 100, 100);

            //backGround
            backGroundTexture = Content.Load<Texture2D>("backGround1");
            backGroundRect = new Rectangle(0, 0, 800, 600);

            IntroBackgroundTexture = Content.Load<Texture2D>("IntroScreen");

            titleFont = Content.Load<SpriteFont>("TextFont");

        }

        protected override void Update(GameTime gameTime)
        {


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            mouseState = Mouse.GetState();



            ///
            ///draws intro screen
            ///
            if (currentScreen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                   currentScreen = Screen.TribbleYard;

            }
            ///
            /// Draws Tribble Yard
            ///
            else if (currentScreen == Screen.TribbleYard)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    currentScreen = Screen.Outtro;

                //Tribble Brown
                tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
                tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
                if (tribbleBrownRect.Right > _graphics.PreferredBackBufferWidth || tribbleBrownRect.Left < 0)
                {
                    tribbleBrownSpeed.X *= -1;
                    tribbleBrownRect.X = rnd.Next(0, _graphics.PreferredBackBufferWidth);

                }

                if (tribbleBrownRect.Top < 0 || tribbleBrownRect.Bottom > _graphics.PreferredBackBufferHeight)
                {
                    tribbleBrownSpeed.Y *= -1;
                    tribbleBrownRect.Y = rnd.Next(0, _graphics.PreferredBackBufferHeight);
                }
                //Tribble Cream
                tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
                tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
                if (tribbleCreamRect.Right > _graphics.PreferredBackBufferWidth || tribbleCreamRect.Left < 0)
                    tribbleCreamSpeed.X *= -1;

                if (tribbleCreamRect.Top < 0 || tribbleCreamRect.Bottom > _graphics.PreferredBackBufferHeight)
                {
                    tribbleCreamSpeed.Y *= -1;
                    rndColor = rnd.Next(0, 7);
                }

                //Tribble Grey
                tribbleGreyRect.X += (int)tribbleGreySpeed.X;
                tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
                if (tribbleGreyRect.Right > _graphics.PreferredBackBufferWidth || tribbleGreyRect.Left < 0)
                    tribbleGreySpeed.X *= -1;

                if (tribbleGreyRect.Top < 0 || tribbleGreyRect.Bottom > _graphics.PreferredBackBufferHeight)
                    tribbleGreySpeed.Y *= -1;

                //Tribble Orange
                tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
                tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
                if (tribbleOrangeRect.Right > _graphics.PreferredBackBufferWidth || tribbleOrangeRect.Left < 0)
                    tribbleOrangeSpeed.X *= -1;

                if (tribbleOrangeRect.Top < 0 || tribbleOrangeRect.Bottom > _graphics.PreferredBackBufferHeight)
                    tribbleOrangeSpeed.Y *= -1;

                base.Update(gameTime);
            }
            ///
            /// Draws outtro
            if(currentScreen == Screen.Outtro)
            {




            }





        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();


            if (currentScreen == Screen.Intro)
            {
                _spriteBatch.Draw(IntroBackgroundTexture, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);

            }
            else if (currentScreen == Screen.TribbleYard)
            {
                //Background
                _spriteBatch.Draw(backGroundTexture, backGroundRect, Color.White);

                //Tribble Brown
                _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);

                //Tribble Cream
                _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, tribbleColourList[rndColor]);

                //Tribble Grey
                _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);

                //Tribble Orange
                _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
            }
                _spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
