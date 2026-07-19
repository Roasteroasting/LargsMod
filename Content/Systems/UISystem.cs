using LargsMod.Configs;
using LargsMod.Content.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Policy;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace LargsMod.Content.Systems
{
    public class UISystem : ModSystem
    {
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            Player player = Main.LocalPlayer;
            var mp = player.GetModPlayer<LargsPlayer>();
            Texture2D tex = TextureAssets.MagicPixel.Value;

            // ==========================================
            // 1. MOMENTUM BAR (World-Space under Player)
            // ==========================================
            var config = ModContent.GetInstance<ClientConfig>();
            if (config.ShowMomentumBar)
            {
                Vector2 screenPos = player.Bottom.ToScreenPosition() + new Vector2(0f, 16f);

                float mWidth = 60f;
                float mHeight = 6f;
                float fillRatio = mp.momentum / 100f;

                // Background
                spriteBatch.Draw(tex,
                    screenPos - new Vector2(mWidth / 2f, 0f),
                    new Rectangle(0, 0, 1, 1),
                    Color.Black * 0.6f,
                    0f, Vector2.Zero,
                    new Vector2(mWidth, mHeight),
                    SpriteEffects.None, 0f);

                // Progress Fill (Color shifts Red -> LimeGreen)
                spriteBatch.Draw(tex,
                    screenPos - new Vector2(mWidth / 2f, 0f),
                    new Rectangle(0, 0, 1, 1),
                    Color.Lerp(Color.Red, Color.LimeGreen, fillRatio),
                    0f, Vector2.Zero,
                    new Vector2(mWidth * fillRatio, mHeight),
                    SpriteEffects.None, 0f);

                // Label
                Vector2 textPos = screenPos + new Vector2(0f, 26f);
                var font = FontAssets.MouseText.Value;
                string text = "Momentum";

                ChatManager.DrawColorCodedStringWithShadow(
                    spriteBatch, font, text, textPos, Color.White, 0f,
                    font.MeasureString(text) / 2f, Vector2.One
                );
            }

            // ==========================================
            // 2. WEAPON COOLDOWN BARS (Screen-Space Stack)
            // ==========================================
            int activeBarsCount = 0;

            // Electric Railcannon
            if (mp.electricRailcannonCooldown > 0)
            {
                DrawCooldownElement(spriteBatch, tex, "Electric Railcannon", mp.electricRailcannonCooldown, 16f * 60f, Color.Cyan, activeBarsCount);
                activeBarsCount++;
            }

            // Thermiload
            if (mp.thermiloadCooldown > 0)
            {
                DrawCooldownElement(spriteBatch, tex, "Thermiload", mp.thermiloadCooldown, 900f, Color.OrangeRed, activeBarsCount);
                activeBarsCount++;
            }
        }

        private void DrawCooldownElement(SpriteBatch spriteBatch, Texture2D tex, string label, int cooldown, float maxCooldown, Color color, int index)
        {
            float progress = cooldown / maxCooldown;
            progress = MathHelper.Clamp(progress, 0f, 1f);

            int verticalOffset = index * 45;
            Vector2 barPos = new Vector2(20, Main.screenHeight - 40 - verticalOffset);
            Vector2 labelPos = new Vector2(20, Main.screenHeight - 65 - verticalOffset);

            int width = 200;
            int height = 10;

            Rectangle bg = new Rectangle((int)barPos.X, (int)barPos.Y, width, height);
            Rectangle fill = new Rectangle((int)barPos.X, (int)barPos.Y, (int)(width * progress), height);

            spriteBatch.Draw(tex, bg, Color.Black * 0.6f);
            spriteBatch.Draw(tex, fill, color);

            ChatManager.DrawColorCodedStringWithShadow(
                spriteBatch, FontAssets.MouseText.Value, label, labelPos, color,
                0f, Vector2.Zero, Vector2.One
            );
        }
    }
}