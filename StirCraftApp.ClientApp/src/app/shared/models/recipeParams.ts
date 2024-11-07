export class RecipeParams {
  pageNumber = 1;
  pageSize = 5;
  searchName: string = '';
  categories: string[] = [];
  difficultyLevels: string[] = [];
  sort = 'default';
}