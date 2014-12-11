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
        enum GameStates {TitleScreen, Playing, PlayerDead, GameOver, Settings};
        GameStates state = GameStates.TitleScreen;
        Texture2D titleScreen;
        Texture2D cursorSheet;
        Texture2D WeaponShelterSheet;
        Sprite Cursor;
        SpriteFont pericles14;
        WeaponManager weaponManager;
        ShelterManager shelterManager;
        public static int WoodCount=0,StoneCount = 0,IronCount = 0;

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
            WeaponShelterSheet = Content.Load<Texture2D>(@"Sheet");
            cursorSheet = Content.Load<Texture2D>(@"cursor");
            Cursor = new Sprite(Vector2.Zero, cursorSheet, new Rectangle(0, 0, 13, 20), Vector2.Zero);
            //EffectManager.Initialize(graphics, Content);
            //EffectManager.LoadContent();
            pericles14 = Content.Load<SpriteFont>(@"Pericles14");
            weaponManager = new WeaponManager(WeaponShelterSheet);
            shelterManager =new ShelterManager(WeaponShelterSheet);

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
                state = GameStates.Playing;
            if (nothingButton.Intersects(Cursor.BoundingBoxRect) && ms.LeftButton == ButtonState.Pressed)
                state = GameStates.PlayerDead;
            if (OptionsButton.Intersects(Cursor.BoundingBoxRect) && ms.LeftButton == ButtonState.Pressed)
                state = GameStates.Settings;

            weaponManager.Update(gameTime,ms);
            shelterManager.Update(gameTime,ms);
            //EffectManager.Update(gameTime);
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
             if (state == GameStates.Playing)
             {
                 shelterManager.Draw(spriteBatch);
                 weaponManager.Draw(spriteBatch);
                 spriteBatch.DrawString(pericles14, "Wood: "+WoodCount, new Vector2(687, 10), Color.White);
                 spriteBatch.DrawString(pericles14, "Stone: " + StoneCount, new Vector2(685, 25), Color.White);
                 spriteBatch.DrawString(pericles14, "iron: " + IronCount, new Vector2(700, 40), Color.White);
             }
            //EffectManager.Draw(); 
            Cursor.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}