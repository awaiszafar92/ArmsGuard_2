namespace ARMSGUARD.Models;

public sealed record WeaponItem(
    string Id,
    string Name,
    string Manufacturer,
    string Category,
    string Type,
    string Caliber,
    string Action,
    string Image,
    string Description,
    string SafetyInformation,
    string LegalInformation);

public static class WeaponCatalog
{
    public static IReadOnlyList<WeaponItem> Items { get; } =
    [
        new("atlas-compact", "Atlas Compact", "Northstar Arms", "Handguns", "Semi-automatic", "9×19 mm", "Short-recoil operated", "/images/catalog-handgun.svg", "A compact, sample catalog entry presented for general identification and educational reference.", "Always treat any firearm as loaded, keep it pointed in a safe direction, and follow the manufacturer's instructions.", "Ownership, possession, and transfer rules vary by jurisdiction. Verify all applicable requirements with qualified local authorities."),
        new("ridgefield-sport", "Ridgefield Sport", "Meridian Sporting", "Rifles", "Sporting rifle", ".22 LR", "Bolt action", "/images/catalog-rifle.svg", "A fictional sporting-rifle entry demonstrating the catalog's general information format.", "Use only in a controlled, lawful environment with appropriate supervision and protective equipment.", "This demonstration record does not verify availability, eligibility, or legal status in any jurisdiction."),
        new("heritage-field", "Heritage Field", "Cedar & Vale", "Shotguns", "Field shotgun", "12 gauge", "Break action", "/images/catalog-shotgun.svg", "A fictional field-shotgun entry included solely as an informational catalog example.", "Keep the action open when not in use and follow safe storage guidance from qualified safety organizations.", "Always consult applicable laws and licensing authorities before acquiring, possessing, or using regulated items."),
        new("legacy-1874", "Legacy 1874", "Oldstone Works", "Historical Firearms", "Historical reproduction", ".45-70 Government", "Single-shot", "/images/catalog-historical.svg", "A fictional historical-style catalog record for educational reference and classification.", "Historical and replica items can still be dangerous. Handle only with appropriate training and care.", "Legal classification of antiques and reproductions differs by location. Confirm requirements with local authorities.")
    ];
}
