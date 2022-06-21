import { Component, OnInit } from '@angular/core';
import { ContractModel } from '../models/Contract';
import { DataService } from '../services/data-service.service';

@Component({
  selector: 'app-tenant-rentals',
  templateUrl: './tenant-rentals.component.html',
  styleUrls: ['./tenant-rentals.component.scss']
})
export class TenantRentalsComponent implements OnInit {

  constructor(private dataService: DataService) { }
  public contracts: ContractModel[] = [];
  async ngOnInit(): Promise<void> {
    this.contracts = (await this.dataService.getContractByTenantId(Number(localStorage.getItem("userId"))))!;
  }

}
