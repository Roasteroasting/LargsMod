using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using LargsMod.Content.Players;
using Terraria.GameContent;
using Terraria.UI.Chat;

namespace LargsMod.Content.Systems
{
    public class ElectricRailcannonCooldownUISystem : ModSystem
    {
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            Player player = Main.LocalPlayer;
            var mp = player.GetModPlayer<LargsPlayer>();

            if (mp.electricRailcannonCooldown <= 0)
                return;

            DrawHotbarCooldownBar(spriteBatch, mp.electricRailcannonCooldown);
            DrawLabel(spriteBatch);
        }

        private void DrawHotbarCooldownBar(SpriteBatch spriteBatch, int cooldown)
        {
            float progress = cooldown / (16f * 60f);
            progress = MathHelper.Clamp(progress, 0f, 1f);

            Vector2 pos = new Vector2(20, Main.screenHeight - 40);

            int width = 200;
            int height = 10;

            Rectangle bg = new Rectangle((int)pos.X, (int)pos.Y, width, height);
            Rectangle fill = new Rectangle((int)pos.X, (int)pos.Y, (int)(width * progress), height);

            spriteBatch.Draw(TextureAssets.MagicPixel.Value, bg, Color.Black * 0.6f);
            spriteBatch.Draw(TextureAssets.MagicPixel.Value, fill, Color.Cyan);
        }

        private void DrawLabel(SpriteBatch spriteBatch)
        {
            Vector2 labelPos = new Vector2(20, Main.screenHeight - 55);

            ChatManager.DrawColorCodedStringWithShadow(
              spriteBatch,
              FontAssets.MouseText.Value,
              "Electric Railcannon",
              labelPos,
              Color.Cyan,
              0f,
              Vector2.Zero,
              Vector2.One
            );
        }
    }
}
