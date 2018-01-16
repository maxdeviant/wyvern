module Wyvern.EntityComponentSystem.ComponentId

type T = ComponentId of int

let mutable private internalId = 0

let create() =
  internalId <- internalId + 1
  ComponentId internalId

let apply f (ComponentId id) = f id

let value (ComponentId id) = id
