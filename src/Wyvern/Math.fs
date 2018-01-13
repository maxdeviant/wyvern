module Wyvern.Math

/// Clamps the given value between the specified range.
let clamp min max value =
  let value' = if value > max then max else value
  if value' < min then min else value'
