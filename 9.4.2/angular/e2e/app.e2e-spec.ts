import { EmployeeLeaveManagementSystemTemplatePage } from './app.po';

describe('EmployeeLeaveManagementSystem App', function() {
  let page: EmployeeLeaveManagementSystemTemplatePage;

  beforeEach(() => {
    page = new EmployeeLeaveManagementSystemTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
