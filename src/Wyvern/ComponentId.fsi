module Wyvern.EntityComponentSystem.ComponentId

type T

val create: unit -> T

val apply: (int -> 'a) -> T -> 'a

val value: T -> int
