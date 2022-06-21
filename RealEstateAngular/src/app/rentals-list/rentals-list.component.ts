import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContractModel } from '../models/Contract';
import { DataService } from '../services/data-service.service';

@Component({
  selector: 'app-rentals-list',
  templateUrl: './rentals-list.component.html',
  styleUrls: ['./rentals-list.component.scss']
})
export class RentalsListComponent implements OnInit {

  constructor(private dataService: DataService, private router: Router) { }
  public contracts: ContractModel[] = [];
  async ngOnInit(): Promise<void> {
    this.contracts = (await this.dataService.getContractByLandlordId(Number(localStorage.getItem("userId"))))!;
  }
  openContractPage(contractId: number){
    this.router.navigate(["contract/" + contractId.toString()]);
  }
}
