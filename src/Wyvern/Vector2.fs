namespace Wyvern

open System

type Vector2 = {
  /// The x-component of the vector.
  x: float

  /// The y-component of the vector.
  y: float
} with
  static member (+) (a, b) = { x = a.x + b.x; y = a.y + b.y }

  static member (+) (vector, scalar) = { x = vector.x + scalar; y = vector.y + scalar }

  static member (-) (a, b) = { x = a.x - b.x; y = a.y - b.y }

  static member (-) (vector, scalar) = { x = vector.x - scalar; y = vector.y - scalar }

  static member (*) (a, b) = { x = a.x * b.x; y = a.y * b.y }

  static member (*) (vector, scalar) = { x = vector.x * scalar; y = vector.y * scalar }

  static member (*) (scalar, vector) = { x = vector.x * scalar; y = vector.y * scalar }

  static member (/) (a, b) = { x = a.x / b.x; y = a.y / b.y }

  static member (/) (vector, scalar) = { x = vector.x / scalar; y = vector.y / scalar }

module Vector2 =
  /// A vector with components (0, 0).
  let zero = { x = 0.0; y = 0.0 }

  /// A vector with components (1, 0).
  let unitX = { x = 1.0; y = 0.0 }

  /// A vector with components (0, 1).
  let unitY = { x = 0.0; y = 1.0 }

  /// A vector with components (1, 1).
  let unit = { x = 1.0; y = 1.0 }

  /// Negates the given vector.
  let negate (vector: Vector2) = -1.0 * vector

  /// Clamps the given vector between the specified range.
  let clamp min max vector =
    let clamp' = Math.clamp min max
    { x = clamp' vector.x; y = clamp' vector.y }

  /// Returns the squared distance between two vectors.
  let distanceSquared a b =
    let deltaX = a.x - b.x
    let deltaY = a.y - b.y
    (deltaX ** 2.0) + (deltaY ** 2.0)

  /// Returns the distance between two vectors.
  let distance a b =
    distanceSquared a b |> Math.Sqrt

  /// Normalizes the given vector.
  let normalize vector =
    assert (vector <> zero)
    let value = 1.0 / Math.Sqrt ((vector.x ** 2.0) + (vector.y ** 2.0))
    vector * value

  /// Tries to normalize the given vector.
  let tryNormalize vector =
    if vector = zero then None
    else Some (normalize vector)
