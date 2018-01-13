namespace Wyvern

open System

type Vector4 = {
  /// The x-component of the vector.
  x: float

  /// The y-component of the vector.
  y: float

  /// The z-component of the vector.
  z: float

  /// The w-component of the vector.
  w: float
} with
  static member (+) (a, b) =
    {
      x = a.x + b.x
      y = a.y + b.y
      z = a.z + b.z
      w = a.w + b.w
    }

  static member (+) (vector, scalar) =
    {
      x = vector.x + scalar
      y = vector.y + scalar
      z = vector.z + scalar
      w = vector.w + scalar
    }

  static member (-) (a, b) =
    {
      x = a.x - b.x
      y = a.y - b.y
      z = a.z - b.z
      w = a.w - b.w
    }

  static member (-) (vector, scalar) =
    {
      x = vector.x - scalar
      y = vector.y - scalar
      z = vector.z - scalar
      w = vector.w - scalar
    }

  static member (*) (a, b) =
    {
      x = a.x * b.x
      y = a.y * b.y
      z = a.z * b.z
      w = a.w * b.w
    }

  static member (*) (vector, scalar) =
    {
      x = vector.x * scalar
      y = vector.y * scalar
      z = vector.z * scalar
      w = vector.w * scalar
    }

  static member (*) (scalar, vector) =
    {
      x = vector.x * scalar
      y = vector.y * scalar
      z = vector.z * scalar
      w = vector.w * scalar
    }

  static member (/) (a, b) =
    {
      x = a.x / b.x
      y = a.y / b.y
      z = a.z / b.z
      w = a.w / b.w
    }

  static member (/) (scalar, vector) =
    {
      x = vector.x / scalar
      y = vector.y / scalar
      z = vector.z / scalar
      w = vector.w / scalar
    }

module Vector4 =
  /// A vector with components (0, 0, 0, 0).
  let zero =
    {
      x = 0.0
      y = 0.0
      z = 0.0
      w = 0.0
    }

  /// A vector with components (1, 1, 1, 1).
  let one =
    {
      x = 1.0
      y = 1.0
      z = 1.0
      w = 1.0
    }
