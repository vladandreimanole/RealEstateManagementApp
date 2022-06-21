import { PropertyModel } from "./Property"
import { User } from "./User"

export class ContractModel{
    contractId?: number
    propertyId?: number
    tenantId?: number
    signed?: boolean
    property?: PropertyModel
    tenant?: User
    contractHTML?: string
}