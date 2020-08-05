namespace tbd.database
{
    using Microsoft.EntityFrameworkCore;
    using Npgsql;

    public sealed class TdbDbError
    {
        private readonly DbUpdateException _exception;

        public TdbDbError(DbUpdateException exception)
        {
            this._exception = exception;
        }

        private PostgresException PostgresException
            => this._exception.InnerException as PostgresException;

        public bool IsUniqueViolation()
        {
            PostgresException exception = this.PostgresException;
            if (exception == null)
            {
                return false;
            }

            return exception.SqlState == PostgresErrorCodes.UniqueViolation;
        }
    }
}