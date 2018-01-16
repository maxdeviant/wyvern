module Wyvern.EntityComponentSystem.ComponentId

type T = ComponentId of int

let mutable private id = 0

let create() =
  id <- id + 1
  ComponentId id
