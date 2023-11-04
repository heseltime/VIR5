namespace NotesAPI {
  public static class NotesContextSingleton {
    private static readonly NotesContext context = new();
    public static NotesContext Context => context;
  }
}
