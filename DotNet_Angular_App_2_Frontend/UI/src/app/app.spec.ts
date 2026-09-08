import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideHttpClient } from '@angular/common/http';
import { App } from './app';

describe('App', () => {
  let fixture: ComponentFixture<App>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [App],
      providers: [provideHttpClient()],
    }).compileComponents();
    fixture = TestBed.createComponent(App);
  });

  it('should create the app', () => {
    expect(fixture.componentInstance).toBeTruthy();
  });

  it('should render the application outlet', () => {
    expect(fixture.nativeElement.querySelector('router-outlet')).toBeTruthy();
  });
});
