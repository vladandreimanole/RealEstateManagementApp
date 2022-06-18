import { Component, OnInit } from '@angular/core';
import { ContractModel } from '../models/Contract';
import { DataService } from '../services/data-service.service';

@Component({
  selector: 'app-rentals-list',
  templateUrl: './rentals-list.component.html',
  styleUrls: ['./rentals-list.component.css']
})
export class RentalsListComponent implements OnInit {

  constructor(private dataService: DataService) { }
  public contracts: ContractModel[] = [];
  async ngOnInit(): Promise<void> {
    this.contracts = (await this.dataService.getContractByLandlordId(Number(localStorage.getItem("userId"))))!;
  }

}
