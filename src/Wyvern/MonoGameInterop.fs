module internal Wyvern.MonoGameInterop

open Microsoft.Xna.Framework

let toVector2 (vector2: Wyvern.Vector2) =
  new Vector2(float32 vector2.x, float32 vector2.y)
