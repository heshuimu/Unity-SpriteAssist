﻿using System.Collections.Generic;
using UnityEngine;

namespace SpriteAssist
{
    public class TransparentMeshCreator : MeshCreatorBase
    {
        public override void OverrideGeometry(Sprite sprite, SpriteConfigData data)
        {
            sprite.GetMeshData(data, out var vertices, out var triangles, MeshRenderType.Transparent);
            sprite.SetSpriteScaleToVertices(vertices, 1, false, false);
            sprite.OverrideGeometry(vertices, triangles);
        }

        public override GameObject CreateExternalObject(Sprite sprite, SpriteConfigData data)
        {
            GameObject prefab = sprite.CreateEmptyMeshPrefab(false);
            sprite.GetMeshData(data, out var vertices, out var triangles, MeshRenderType.Transparent);
            sprite.AddComponentsAssets(vertices, triangles, prefab, RENDER_TYPE_TRANSPARENT, data.transparentShader);
            return prefab;
        }

        public override List<SpritePreviewWireframe> GetMeshWireframes()
        {
            return new List<SpritePreviewWireframe>()
            {
                new SpritePreviewWireframe(SpritePreviewWireframe.transparentColor, MeshRenderType.Transparent)
            };
        }
    }

}