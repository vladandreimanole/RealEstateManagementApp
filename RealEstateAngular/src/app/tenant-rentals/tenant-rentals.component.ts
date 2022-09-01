import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContractModel } from '../models/Contract';
import { DataService } from '../services/data-service.service';

@Component({
  selector: 'app-tenant-rentals',
  templateUrl: './tenant-rentals.component.html',
  styleUrls: ['./tenant-rentals.component.scss']
})
export class TenantRentalsComponent implements OnInit {

  constructor(private dataService: DataService, private router: Router) { }
  public contracts: ContractModel[] = [];
  async ngOnInit(): Promise<void> {
    this.contracts = (await this.dataService.getContractByTenantId(Number(localStorage.getItem("userId"))))!;
  }
  openContractPage(contractId: number){
    this.router.navigate(["contract/" + contractId.toString()]);
  }
  deleteContract(contractId: number){
    this.dataService.deleteContract(contractId);
    this.contracts = this.contracts.filter(contract => contract.contractId != contractId);
  }
}
