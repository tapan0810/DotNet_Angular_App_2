import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainClass } from './main-class';

describe('MainClass', () => {
  let component: MainClass;
  let fixture: ComponentFixture<MainClass>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MainClass],
    }).compileComponents();

    fixture = TestBed.createComponent(MainClass);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
