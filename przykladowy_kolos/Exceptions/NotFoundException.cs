namespace przykladowy_kolos.Exceptions;

public class NotFoundException(string message) : Exception(message);


//zamiast tego możnaby rzucic InvalidOperationException