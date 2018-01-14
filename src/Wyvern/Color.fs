namespace Wyvern

type Color = Color of uint32

module Color =
  let make value =
    Color (uint32 value)

  let r color =
    match color with Color value -> byte (value >>> 24)

  let g color =
    match color with Color value -> byte (value >>> 16)

  let b color =
    match color with Color value -> byte (value >>> 8)

  let a color =
    match color with Color value -> byte value
  //open System
  //open Math

  //let rgb r g b alpha =
  //  if ((r ||| g ||| b ||| alpha) &&& 0xffffff00) <> 0
  //  then
  //    let clamp' = Math.clamp (int Byte.MinValue) (int Byte.MaxValue)
  //    let packedValue = ((clamp' alpha) <<< 24) ||| ((clamp' b) <<< 16) ||| ((clamp' g) <<< 8) ||| (clamp' r)
  //    Color (uint32 packedValue)
  //  else Color 
  //    //Color ((clampedR <<< 24) ||| (clampedG <<< 16) ||| (clampedB <<< 8))