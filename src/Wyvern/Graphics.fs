﻿module Wyvern.Graphics

open Microsoft.Xna.Framework.Graphics
open System
open System.IO

type Texture internal (texture: Texture2D) =
  member internal __.Texture = texture
  member __.Dimensions = (texture.Width, texture.Height)

  interface IDisposable with
    override __.Dispose() =
      __.Texture.Dispose()

let loadTexture graphicsDevice contentRoot path =
  let absolutePath = Path.Combine (contentRoot path)
  try
    use fileStream = new FileStream(absolutePath, FileMode.Open)
    Some (new Texture(Texture2D.FromStream(graphicsDevice, fileStream)))
  with
  | _ -> None

let createTexture graphicsDevice (width, height) color =
  let texture = new Texture2D(graphicsDevice, width, height)
  let colorData = [| for _ in 0 .. (width * height) - 1 -> Wyvern.MonoGameInterop.toColor color |]
  texture.SetData colorData
  new Texture(texture)