export type RecipeShort = {
    id: number;
    name: string;
    difficultyLevel: string;
    imageUrl?: string | null;
    cookName: string;
    rating: number;
    likes: number;
    categories: string[];
}