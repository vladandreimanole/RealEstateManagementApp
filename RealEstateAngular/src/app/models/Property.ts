import { UploadedImages } from "./UploadedImages"
import { User } from "./User"

export class PropertyModel {
    propertyId: number = 0
    propertyName?: string
    city?: string
    address?: string
    value?: number
    userId?: number
    user?: User
    unlisted?: boolean = false
    uploadedImages?: UploadedImages[]
  }