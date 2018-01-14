module internal Wyvern.MonoGameInterop

open Wyvern

type MonoGameVector2 = Microsoft.Xna.Framework.Vector2

let toVector2 (vector2: Vector2) =
  new MonoGameVector2(float32 vector2.x, float32 vector2.y)

type MonoGameColor = Microsoft.Xna.Framework.Color

let toColor (color: Color) =
  new MonoGameColor(Color.r color, Color.g color, Color.b color, Color.a color)
