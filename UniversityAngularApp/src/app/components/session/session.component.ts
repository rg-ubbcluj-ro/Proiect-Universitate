import { Component, OnInit } from '@angular/core';
import { SessionService } from 'src/app/services/session.service';
import { SessionItem} from 'src/app/models/session-items';

@Component({
  selector: 'app-session',
  templateUrl: './session.component.html',
  styleUrls: ['./session.component.scss']
})
export class SessionComponent implements OnInit {
  sessionItems : SessionItem[] = [];
  newSessionItem : SessionItem = {};
  updateSessionItem : SessionItem = {};
  idSession = 0;
  constructor(private sessionService : SessionService) { }

  ngOnInit(): void {
    this.sessionService.getSessions()
    .subscribe((sessionItems: SessionItem[]) => {
      this.sessionItems=sessionItems;
    });
  }
  addSessionItem() {
    this.sessionService.addSessionItem(this.newSessionItem)
    .subscribe((sessionItems) =>
    this.sessionItems.push(sessionItems));
    this.newSessionItem = {};
  }
  
  deleteSessionItem(id: number) { 
    this.sessionService.deleteSessionItem(id).subscribe((id) => { this.ngOnInit(); });
  }
  updateSessionItems() {
    if (this.updateSessionItem.id) {
      this.sessionService.updateSessionItem(this.updateSessionItem).subscribe((sessionItem) => 
       this.sessionItems.push(sessionItem));
      }
      window.location.reload();
    this.updateSessionItem = {};
    }
}

