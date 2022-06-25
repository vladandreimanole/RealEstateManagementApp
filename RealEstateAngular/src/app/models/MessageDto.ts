import { DateSelectionModelChange } from "@angular/material/datepicker";

export class MessageDto {
    public msgText: string = '';
    public chatId?: string;
    public tenantId?: number;
    public landlordId?: number;
    public sentTime?: Date;
    public sentByUserId?: number;
  }