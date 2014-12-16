using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Colonization
{
  
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        enum GameStates {TitleScreen, Intermission , DuringWave, GameOver, Settings};
        GameStates state = GameStates.TitleScreen;
        Texture2D titleScreen;
        Texture2D backdrop;
        Texture2D mainscreen;
        Texture2D cursorSheet;
        Texture2D tooltipSheet;
        Texture2D WeaponShelterSheet;
        Sprite Cursor;
        SpriteFont pericles14, pericles2;
        WeaponManager weaponManager;
        ShelterManager shelterManager;
        public static int WoodCount=0,StoneCount = 0,IronCount = 0,Wave =0;
        public static double TimeHour = 12;
        public static double TimeMinutes = 00;
        public static double TimeSeconds = 00;
        PlayerManager player;
        
        bool isAM = true;


        Rectangle StartButton =   new Rectangle(331, 260, 150, 50);
        Rectangle nothingButton = new Rectangle(74, 292, 150, 50);
        Rectangle OptionsButton = new Rectangle(579, 291, 150, 50);
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.PreferredBackBufferHeight = 600;
            //graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
           // this.IsMouseVisible = true;
            base.Initialize();
          
          
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            titleScreen = Content.Load<Texture2D>(@"TitleScreen");
            backdrop = Content.Load<Texture2D>(@"backdrop");
            mainscreen = Content.Load<Texture2D>(@"MainScreen");
            WeaponShelterSheet = Content.Load<Texture2D>(@"Sheet");
            cursorSheet = Content.Load<Texture2D>(@"cursor");
            tooltipSheet = Content.Load<Texture2D>(@"ToolTip");
            Cursor = new Sprite(Vector2.Zero, cursorSheet, new Rectangle(0, 0, 13, 20), Vector2.Zero);
            //EffectManager.Initialize(graphics, Content);
            //EffectManager.LoadContent();
            pericles14 = Content.Load<SpriteFont>(@"Pericles14");
            pericles2 = Content.Load<SpriteFont>(@"Pericles2");
            weaponManager = new WeaponManager(WeaponShelterSheet);
            shelterManager =new ShelterManager(WeaponShelterSheet);
            player = new PlayerManager(WeaponShelterSheet);
            ToolTip.AssignTexture(tooltipSheet);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            Cursor.Location = new Vector2(ms.X, ms.Y);
            if (StartButton.Intersects(Cursor.BoundingBoxRect) && ms.LeftButton == ButtonState.Pressed)
                state = GameStates.Intermission;
            if (nothingButton.Intersects(Cursor.BoundingBoxRect) && ms.LeftButton == ButtonState.Pressed)
                Console.WriteLine("YAYYY");
            if (OptionsButton.Intersects(Cursor.BoundingBoxRect) && ms.LeftButton == ButtonState.Pressed)
                state = GameStates.Settings;
            
            if (state == GameStates.Intermission || state == GameStates.DuringWave)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                    this.Window.Title = ms.X + " " + ms.Y;
                player.update(gameTime);
                if (TimeSeconds >= 55)
                {
                    TimeMinutes++;
                    TimeSeconds = 0;
                }
                if (TimeMinutes < 60)
                    TimeSeconds += 1;
                else
                {
                    if (TimeHour == 12)
                    {
                        TimeHour = 1;
                        if (isAM) isAM = false;
                        else isAM = true;
                    }
                    else
                        TimeHour++;
                    TimeMinutes = 01;
                }
                weaponManager.Update(gameTime, ms);
                shelterManager.Update(gameTime, ms);
                //EffectManager.Update(gameTime);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
             spriteBatch.Begin();
            
            if (state == GameStates.TitleScreen)
            spriteBatch.Draw(titleScreen, new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height), Color.White);
           
             if (state == GameStates.Settings)
                 spriteBatch.DrawString(
                 pericles14,
                 "Why did you click this button you idiot!",
                 new Vector2(280,240),
                 Color.White);
             if (state == GameStates.Intermission || state == GameStates.DuringWave)
             {
                 spriteBatch.Draw(backdrop, new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height), Color.Yellow);
                 spriteBatch.Draw(mainscreen, new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height), Color.White);
                 shelterManager.Draw(spriteBatch);
                 weaponManager.Draw(spriteBatch);
                 spriteBatch.DrawString(pericles14, "Wood: "+WoodCount, new Vector2(687, 10), Color.White);
                 spriteBatch.DrawString(pericles14, "Stone: " + StoneCount, new Vector2(685, 25), Color.White);
                 spriteBatch.DrawString(pericles14, "iron: " + IronCount, new Vector2(700, 40), Color.White);
                 spriteBatch.DrawString(pericles14, "Wave: " + Wave, new Vector2(365, 10), Color.White);
                 player.Player.Draw(spriteBatch);
                 if(isAM)
                 if(TimeMinutes <10)
                     spriteBatch.DrawString(pericles14, "Time: " + TimeHour+":"+"0"+TimeMinutes + " AM", new Vector2(505, 10), Color.White);
                 else spriteBatch.DrawString(pericles14, "Time: " + TimeHour + ":" +  + TimeMinutes + " AM", new Vector2(505, 10), Color.White);
                 else
                     if (TimeMinutes < 10)
                         spriteBatch.DrawString(pericles14, "Time: " + TimeHour + ":" + "0" + TimeMinutes + " PM", new Vector2(505, 10), Color.White);
                     else spriteBatch.DrawString(pericles14, "Time: " + TimeHour + ":" + +TimeMinutes + " PM", new Vector2(505, 10), Color.White);
             }
            //EffectManager.Draw(); 
             ToolTip.drawToolTip(spriteBatch,pericles2);
            Cursor.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
