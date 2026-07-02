using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using LargsMod.Content.Players;
using LargsMod.Configs;
using Terraria.UI.Chat;

namespace LargsMod.Content.Systems
{
    public class MomentumUISystem : ModSystem
    {
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            var config = ModContent.GetInstance<ClientConfig>();

            if (!config.ShowMomentumBar)
                return;

            Player player = Main.LocalPlayer;
            var mp = player.GetModPlayer<LargsPlayer>();

            Vector2 screenPos = player.Bottom.ToScreenPosition();

            screenPos += new Vector2(0f, 16f);

            float width = 60f;
            float height = 6f;
            float fill = mp.momentum / 100f;

            Texture2D tex = Terraria.GameContent.TextureAssets.MagicPixel.Value;

            spriteBatch.Draw(tex,
                screenPos - new Vector2(width / 2f, 0f),
                new Rectangle(0, 0, 1, 1),
                Color.Black * 0.6f,
                0f,
                Vector2.Zero,
                new Vector2(width, height),
                SpriteEffects.None,
                0f);

            spriteBatch.Draw(tex,
                screenPos - new Vector2(width / 2f, 0f),
                new Rectangle(0, 0, 1, 1),
                Color.Lerp(Color.Red, Color.LimeGreen, fill),
                0f,
                Vector2.Zero,
                new Vector2(width * fill, height),
                SpriteEffects.None,
                0f);

            Vector2 textPos = screenPos + new Vector2(0f, 26f);

            var font = Terraria.GameContent.FontAssets.MouseText.Value;

            string text = "Momentum";

            ChatManager.DrawColorCodedStringWithShadow(
                spriteBatch,
                font,
                text,
                textPos,
                Color.White,
                0f,
                font.MeasureString(text) / 2f,
                Vector2.One
            );
        }
    }
}