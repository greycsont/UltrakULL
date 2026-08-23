using System;
using UnityEngine;
using UnityEngine.UI;

namespace UltrakULL;

public static partial class TextureSwapper
{
    private static void ReplaceImages()
    {
        foreach (var image in Resources.FindObjectsOfTypeAll<Image>())
        {
            ReplaceSpriteSlot(image, "Image.sprite", image.sprite,
                value => image.sprite = value, "Image slot(s)");
            ReplaceSpriteSlot(
                image, "Image.overrideSprite", image.overrideSprite,
                value => image.overrideSprite = value, "Image slot(s)");
        }
    }

    private static void ReplaceRawImages()
    {
        foreach (var image in Resources.FindObjectsOfTypeAll<RawImage>())
            ReplaceTextureSlot(image, "RawImage.texture", image.texture,
                value => image.texture = value, "RawImage(s)");
    }

    private static void ReplaceSpriteRenderers()
    {
        foreach (var renderer in Resources.FindObjectsOfTypeAll<SpriteRenderer>())
            ReplaceSpriteSlot(renderer, "SpriteRenderer.sprite", renderer.sprite,
                value => renderer.sprite = value, "SpriteRenderer(s)");
    }

    private static void ReplaceSpriteMasks()
    {
        foreach (var mask in Resources.FindObjectsOfTypeAll<SpriteMask>())
            ReplaceSpriteSlot(mask, "SpriteMask.sprite", mask.sprite,
                value => mask.sprite = value, "SpriteMask(s)");
    }

    private static void ReplaceSpriteSlot(Component owner, string slot, Sprite current,
        Action<Sprite> assign, string category)
    {
        Sprite desired = GetDesiredSprite(current);
        if (desired == current)
            return;
        LogReplacement(owner, slot, current, desired);
        assign(desired);
        replacementCount[category]++;
    }

    private static void ReplaceTextureSlot(Component owner, string slot, Texture current,
        Action<Texture> assign, string category)
    {
        Texture desired = GetDesiredTexture(current);
        if (desired == current)
            return;
        LogReplacement(owner, slot, current, desired);
        assign(desired);
        replacementCount[category]++;
    }
}
