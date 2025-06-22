using System;

namespace Saas_B2B_Back.Application {
  public class SchemaAttribute: Attribute {
    public string Name { get; set; }
    public SchemaAttribute(string name = null) {
      Name = name;
    }
  }

  public class StoredProcedureAttribute: Attribute {
    public string Schema { get; set; }
    public string Name { get; set; }
    public StoredProcedureAttribute(string schema = null, string name = null) {
      Schema = schema;
      Name = name;
    }
  }
}
