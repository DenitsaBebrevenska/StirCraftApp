export class RecipeParams {
  pageIndex = 1;
  pageSize = 5;
  searchName: string = '';
  categories: string[] = [];
  difficultyLevels: string[] = [];
  sort = 'default';
  ingredientId?: number;
}