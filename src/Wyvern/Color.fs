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
