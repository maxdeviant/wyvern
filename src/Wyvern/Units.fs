﻿module Wyvern.Units

/// Radian.
[<Measure>]
type rad

/// Degree.
[<Measure>]
type deg

let degreesToRadians (degrees: float<deg>) =
  degrees * (System.Math.PI / 180.0<deg/rad>)
