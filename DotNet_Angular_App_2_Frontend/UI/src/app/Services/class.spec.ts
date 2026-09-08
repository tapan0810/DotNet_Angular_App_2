import { TestBed } from '@angular/core/testing';
import { provideHttpClient } from '@angular/common/http';
import { ClassService } from './class';

describe('ClassService', () => {
  let service: ClassService;

  beforeEach(() => {
    TestBed.configureTestingModule({ providers: [ClassService, provideHttpClient()] });
    service = TestBed.inject(ClassService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
